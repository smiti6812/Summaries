import { Injectable } from '@angular/core';
import { Book } from 'src/app/interfaces/book';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  
  _baseUrl: string ="https://localhost:44434/api/Books";

  constructor(private http: HttpClient) { }

  getAllBooks(){
    return this.http.get<Book[]>(this._baseUrl + "/GetBooks");
  }
  addBook(book: Book) {
    return this.http.post(this._baseUrl + "/AddBook/", book);
  }

  getBookById(id: number) {
    return this.http.get<Book>(this._baseUrl + "/SingleBook/" + id);
  }
  updateBook(book: Book) {
    return this.http.put(this._baseUrl + "/UpdateBook/" + book.id, book);
  }

  deleteBook(id: number) {
    return this.http.delete(this._baseUrl + "/DeleteBook/" + id);
  }

}
