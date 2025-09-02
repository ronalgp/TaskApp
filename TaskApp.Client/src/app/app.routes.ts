import { Routes } from '@angular/router';
import { TaskList } from '../components/task-list/task-list';
import { TaskForm } from '../components/task-form/task-form';
import { LoginForm } from '../components/login-form/login-form';
import { RegisterForm } from '../components/register-form/register-form';

export const routes: Routes = [
  { path: '', component: LoginForm },
  { path: 'task', component: TaskList },
  { path: 'add', component: TaskForm },
  { path: 'edit/:id', component: TaskForm },
  { path: 'login', component: LoginForm },
  { path: 'register', component: RegisterForm },
];
