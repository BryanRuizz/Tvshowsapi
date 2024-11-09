import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TvshowsInterface } from 'src/interfaces/TvShowsInterface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private urlApi = 'https://localhost:44303/api/TVShow';//endpoint local
  constructor(private http: HttpClient) { }
  
  public getdata(): Observable<any> {
    return this.http.get<TvshowsInterface[]>(this.urlApi);
  }

  public updateData(id: number, data: TvshowsInterface): Observable<any> {
    const url = `${this.urlApi}/${id}`;
    return this.http.put<TvshowsInterface>(url, data);
  }

  public deleteData(id: number): Observable<any> {
    const url = `${this.urlApi}/${id}`;
    return this.http.delete<number>(url);
  }

  public createData(data: any): Observable<any> {
    return this.http.post<TvshowsInterface>(this.urlApi, data);
  }
}
