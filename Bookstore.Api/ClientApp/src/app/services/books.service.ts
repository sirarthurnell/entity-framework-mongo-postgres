import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Book } from 'src/app/models/book';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private url = environment.baseUrl + 'books/';

  constructor(private http: HttpClient) { }

  create(book: Book): Observable<Book> {
    return this.http.post<Book>(this.url, book);
  }

  getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(this.url);
  }

  get(id: string): Observable<Book> {
    return this.http.get<Book>(`${this.url}/${id}`);
  }

  update(book: Book): Observable<void> {
    return this.http.put<void>(this.url, book);
  }

  delete(id: string): Observable<Book> {
    const params = new HttpParams({
      fromObject: {
        id
      }
    });

    return this.http.delete<Book>(this.url, { params });
  }
}
