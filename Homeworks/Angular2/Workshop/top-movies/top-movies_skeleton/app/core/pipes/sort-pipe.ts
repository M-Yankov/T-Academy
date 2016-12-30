import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sort-movies'
})
export class SortPipe implements PipeTransform {

    transform(items: any[], property: string, ascending: boolean) {
        return items.sort((a: any, b: any) => {
            if (ascending) {
                return a[property].localeCompare(b[property]);
            } else {
                return b[property].localeCompare(a[property]);
            }
        });
    }
}
