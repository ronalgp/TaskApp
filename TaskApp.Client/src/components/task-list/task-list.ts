import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { TaskService } from '../../services/task-service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Taskdetails } from '../../models/taskdetails';
import { AsyncPipe, DatePipe } from '@angular/common';

@Component({
  selector: 'app-task-list',
  imports: [RouterLink, AsyncPipe, DatePipe],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})
export class TaskList implements OnInit {
  private taskSubject = new BehaviorSubject<Taskdetails[]>([]);
  public task$: Observable<Taskdetails[]> = this.taskSubject.asObservable();

  constructor(private taskService: TaskService, private router: Router) {}
  ngOnInit(): void {
    this.loadTaskList();
  }

  loadTaskList(): void {
    this.taskService.getAll().subscribe((tasks: Taskdetails[]) => {
      this.taskSubject.next(tasks);
    });
  }
  deleteTask(task: Taskdetails) {
    if (confirm('Are you sure you want to delete this transaction?')) {
      this.taskService.delete(task.id).subscribe({
        next: () => {
          console.log('Task deleted successfully');
          this.loadTaskList();
        },
        error: (err) => {
          console.error('Error deleting Task:', err);
          alert('Failed to delete the Task. Please try again.');
        },
      });
    }
  }
  editTask(task: Taskdetails) {
     if (task && task.id) {
      this.router.navigate(['/edit/', task.id]);
    }
  }
}
