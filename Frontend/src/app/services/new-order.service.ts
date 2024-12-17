import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment'
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NewOrderService {

    private apiUrl = `${environment.apiUrl}/neworder`;
    constructor(private http: HttpClient) {}
  
    getStatus(): Observable<{ value: string; label: string }[]> {
      return this.http.get<any[]>(this.apiUrl).pipe(
        map((data) => 
          data.map((status) => ({
            value: status.id.toString(), // id como value
            label: status.name           // name como label
          }))
        )
      );
    }

    createOrder(order: any): Observable<any> {
      return this.http.post<any>(this.apiUrl, order);
    }
}
