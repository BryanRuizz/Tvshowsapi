import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-update-tv-show',
  templateUrl: './update-tv-show.component.html',
  styleUrls: ['./update-tv-show.component.css']
})
export class UpdateTvShowComponent {
  validation: boolean = false;
  @Input() isVisible: boolean = false;
  @Input() item: any = { Id: 0, Name: '', Favorite: false };
  @Output() save = new EventEmitter<any>();
  @Output() cancel = new EventEmitter<void>();

  onSave() {
    // console.log("dataa",this.item);
    // Verificar si los campos 'name' y 'favorite' están vacíos
    if (!this.item[0].name || this.item[0].favorite === undefined) {
      // console.log("data",this.item);
      this.validation = true;
    } else {
      this.validation = false;
      this.save.emit(this.item);
      this.isVisible = false;
    }
  }

  onCancel() {
    this.cancel.emit();
    this.isVisible = false;
  }

}
