import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-create-tv-show',
  templateUrl: './create-tv-show.component.html',
  styleUrls: ['./create-tv-show.component.css']
})
export class CreateTvShowComponent {
  validation = false;
  @Input() isVisible: boolean = false; 
  @Input() item: any = { Id: 0, Name: '', Favorite: false };
  @Output() save = new EventEmitter<any>();
  @Output() cancel = new EventEmitter<void>();

  // constructor(private apiservice: ApiService) { }

  onSave() {
 // Verificar si los campos 'name' y 'favorite' están vacíos
 if (!this.item.name || this.item.favorite === undefined) {
  this.validation = true;
} else {
 
  this.validation = false;
  this.save.emit(this.item);
  this.clearItem();
}
  }

  onCancel() {
    this.cancel.emit();
    this.isVisible = false; 
  }
  private clearItem() {
    this.item = { id: 0, name: '', favorite: false };
  }
}
