import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Taskdetails } from '../models/taskdetails';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  protected baseUrl = environment.apiUrl + 'task';

  constructor(private httpClient: HttpClient) {}

  getAll(): Observable<Taskdetails[]> {
    return this.httpClient.get<Taskdetails[]>(`${this.baseUrl}`);
  }
 getById(id: number): Observable<Taskdetails> {
    return this.httpClient.get<Taskdetails>(`${this.baseUrl}/${id}`);
  }
  create(transaction: Taskdetails): Observable<Taskdetails> {
    return this.httpClient.post<Taskdetails>(`${this.baseUrl}`, transaction);
  }
  update(id: number, transaction: Taskdetails): Observable<void> {
    return this.httpClient.put<void>(`${this.baseUrl}/${id}`, transaction);
  }
  delete(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseUrl}/${id}`);
  }
}
