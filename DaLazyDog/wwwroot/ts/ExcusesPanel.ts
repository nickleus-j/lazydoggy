//@import { Component } from '@angular/core'
//@Component({
//    selector: 'app-panel'
//});
 class ExcusePanelComponent{
     Excuses: string[]
     getLength() {
         return this.Excuses!=null? this.Excuses.length:0;
     }
}