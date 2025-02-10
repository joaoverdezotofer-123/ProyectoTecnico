import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'https://localhost:32769/api'; // URL de tu API

  constructor(private http: HttpClient) {}

  // Crear persona
  createPersona(persona: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/personas`, persona);
  }

  // Crear usuario
  createUsuario(usuario: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/usuarios`, usuario);
  }

  // Validar login
  login(credentials: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/auth/login`, credentials);
  }
}
