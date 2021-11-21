import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataTransferService {
    objects = new BehaviorSubject<any>([]);
    cast = this.objects.asObservable();

    sendAnything(data: any){
        this.objects.next(data);
    }

  constructor() { }
}
