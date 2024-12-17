import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { environment } from '../../environments/environment'
import { map } from 'rxjs/operators';


@Injectable({ providedIn: 'root' })
export class CustomerService {
  private apiUrl = `${environment.apiUrl}/customers`;
  constructor(private http: HttpClient) {}

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.apiUrl);
  }

      getCustomersNames(): Observable<{ value: string; label: string }[]> {
        return this.http.get<any[]>(this.apiUrl).pipe(
          map((data) => 
            data.map((status) => ({
              value: status.id.toString(), // id como value
              label: status.name           // name como label
            }))
          )
        );
      }
}
