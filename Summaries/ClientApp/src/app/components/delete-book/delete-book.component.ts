import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../interfaces/book';
import { BookService } from '../../services/book.service';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html',
  styleUrls: ['./delete-book.component.css']
})
export class DeleteBookComponent {
  book: Book;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private service: BookService) { }

  ngOnInit() {
    this.service.getBookById(this.route.snapshot.params.id).subscribe(data => {
      this.book = data;
    })
  }

  deleteBook(id: number) {
    this.service.deleteBook(id).subscribe(data => {
      this.router.navigate(["/books"]);
    })
  }
}
