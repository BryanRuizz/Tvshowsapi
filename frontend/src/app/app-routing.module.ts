import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateTvShowComponent } from './features/create-tv-show/create-tv-show.component';
import { UpdateTvShowComponent } from './features/update-tv-show/update-tv-show.component';

const routes: Routes = [
  // my rotes here
  { path: '', component: CreateTvShowComponent },
  { path: '', component: UpdateTvShowComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
