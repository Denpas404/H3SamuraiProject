import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'samurai-error',
  standalone: true,
})
export class SamuraiErrorPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return null;
  }

}
