import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { environment } from '../../environments/environment'


@Injectable({ providedIn: 'root' })
export class CustomerService {
  private apiUrl = `${environment.apiUrl}/customers`;
  constructor(private http: HttpClient) {}

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl);
  }
}
