import { Component, OnInit } from '@angular/core';
import { BooksService } from 'src/app/services/books.service';
import { BehaviorSubject } from 'rxjs';
import { Book } from 'src/app/models/book';

@Component({
  selector: 'app-books-editor',
  templateUrl: './books-editor.component.html',
  styleUrls: ['./books-editor.component.scss']
})
export class BooksEditorComponent implements OnInit {
  private bookListSubject$ = new BehaviorSubject<Book[]>([]);
  bookList$ = this.bookListSubject$.asObservable();

  editMode: 'edit' | 'new' = 'new';
  formValues = this.createDefaultFormValues();

  constructor(private booksService: BooksService) {}

  ngOnInit() {
    this.refreshBookList();
  }

  editBook(book: Book): void {
    this.editMode = 'edit';
    this.formValues = book;
  }

  saveBook(): void {
    if (this.editMode === 'edit') {
      this.booksService
        .update(this.formValues)
        .subscribe(_ => this.setDefaults());
    } else {
      const newBook = Object.assign({}, this.formValues);
      newBook.id = this.uuidv4();

      this.booksService
        .create(newBook)
        .subscribe(_ => this.setDefaults());
    }
  }

  setDefaults(): void {
    this.editMode = 'new';
    this.formValues = this.createDefaultFormValues();
    this.refreshBookList();
  }

  deleteBook(id: string): void {
    this.booksService.delete(id).subscribe(_ => this.refreshBookList());
  }

  private refreshBookList(): void {
    this.booksService
      .getAll()
      .subscribe(books => this.bookListSubject$.next(books));
  }

  private createDefaultFormValues(): Book {
    return {
      id: '',
      bookName: '',
      price: 0,
      category: '',
      author: ''
    };
  }

  private uuidv4() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, c => {
      // tslint:disable-next-line:no-bitwise
      const r = (Math.random() * 16) | 0;
      // tslint:disable-next-line:no-bitwise
      const v = c === 'x' ? r : (r & 0x3) | 0x8;
      return v.toString(16);
    });
  }
}
