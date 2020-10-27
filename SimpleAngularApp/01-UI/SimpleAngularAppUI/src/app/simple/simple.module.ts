import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SimpleComponent } from './components/simple/simple.component';

@NgModule({
  declarations: [
    SimpleComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    SimpleComponent
  ]
})
export class SimpleModule { }
