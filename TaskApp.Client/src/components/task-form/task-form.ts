import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../services/task-service';

@Component({
  selector: 'app-task-form',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './task-form.html',
  styleUrl: './task-form.css',
})
export class TaskForm implements OnInit {
  taskForm: FormGroup;

  editMode = false;
  taskId?: number;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private taskService: TaskService,
    private activitedRoute: ActivatedRoute
  ) {
    this.taskForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      dueDate: ['', Validators.required],
      status: ['Ready', Validators.required],
    });
  }

  loadTaskList(tasId: number): void {
    this.taskService.getById(tasId).subscribe({
      next: (task) => {
        this.taskForm.patchValue({
          title: task.title,
          description: task.description,
          dueDate: task.dueDate,
          status: task.status,
        });
      },
      error: (err) => {
        console.error('Error loading transaction', err);
      },
    });
  }

  ngOnInit(): void {
    const id = this.activitedRoute.snapshot.paramMap.get('id');
    if (id) {
      this.editMode = true;
      this.taskId = +id;
      this.loadTaskList(this.taskId);
    }
  }

  cancel() {
    this.router.navigate(['/']);
  }

  onSubmit() {
    if (this.taskForm.valid) {
      const task = this.taskForm.value;
      if (this.editMode && this.taskId) {
        task.id = this.taskId;
        console.log("Task updated : ", task);
        this.taskService.update(task.id, task).subscribe({
          next: () =>{
            this.router.navigate(['/']);
          },
          error: (err) => {
            console.log("Error updating task: ", err);
          }
        });
      } else {
        this.taskService.create(task).subscribe({
          next: () =>{
            this.router.navigate(['/']);
          },
          error: (err) => {
            console.log("Error adding task: ", err);
          }
        });
      }
    }
  }
}
