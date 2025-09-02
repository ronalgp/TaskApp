import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { AuthResponse } from '../models/authresponse';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  private baseUrl = environment.apiUrl + 'user';
  private currentUserSubject = new BehaviorSubject<string | null>(null);

  currentUser$ = this.currentUserSubject.asObservable();

  constructor(private http: HttpClient, private router: Router) {
    const token = localStorage.getItem('token');
    if (token) {
      this.currentUserSubject.next('user');
    }
  }

  login(credentials: User): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.baseUrl}/Login`, credentials)
      .pipe(
        tap((response: AuthResponse) => {
          console.log('response')
          localStorage.setItem('token', response.token);
          this.currentUserSubject.next('user');
        })
      );
  }

  register(credentials: User): Observable<AuthResponse>{
    return this.http
      .post<AuthResponse>(`${this.baseUrl}/Register`, credentials)
      .pipe(
        tap((response: AuthResponse) => {
          localStorage.setItem('token', response.token);
          this.currentUserSubject.next('user');
        })
      );
  }

  logout(): void{
    localStorage.removeItem('token');
    this.currentUserSubject.next(null);
    this.router.navigate(['/login']);
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !!token;
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
