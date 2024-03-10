import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PersonalDataFormComponent } from './personal-data-form/personal-data-form.component';

const routes: Routes = [
  {path:'home',component:HomeComponent},
  {path:'personal-data-form',component:PersonalDataFormComponent},
  {path:'**',redirectTo:'home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }