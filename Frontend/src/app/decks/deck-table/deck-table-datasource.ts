import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge } from 'rxjs';
import { DeckModel } from '../models/DeckModel';

export class DeckTableDataSource extends DataSource<DeckModel> {

  constructor(private paginator: MatPaginator, private sort: MatSort, public data: DeckModel[] ) {
    super();
  }

  connect(): Observable<DeckModel[]> {

    const dataMutations = [
      observableOf(this.data),
      this.paginator.page,
      this.sort.sortChange
    ];

    this.paginator.length = this.data.length;

    return merge(...dataMutations).pipe(map(() => {
      return this.getPagedData(this.getSortedData([...this.data]));
    }));
  }

  disconnect() {}

  private getPagedData(data: DeckModel[]) {
    const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
    return data.splice(startIndex, this.paginator.pageSize);
  }

  private getSortedData(data: DeckModel[]) {
    if (!this.sort.active || this.sort.direction === '') {
      return data;
    }

    return data.sort((a, b) => {
      const isAsc = this.sort.direction === 'asc';
      switch (this.sort.active) {
        case 'name': return compare(a.name, b.name, isAsc);
        case 'creator': return compare(a.creator, b.creator, isAsc);
        case 'languageFrom': return compare(a.languageFrom, b.languageFrom, isAsc);
        case 'languageTo': return compare(a.languageTo, b.languageTo, isAsc);
        case 'cards': return compare(+a.cards, +b.cards, isAsc);
        case 'subscribers': return compare(+a.subscribers, +b.subscribers, isAsc);
        case 'index': return compare(+a['index'], +b['index'], isAsc);
        case 'id': return compare(+a.id, +b.id, isAsc);
        default: return 0;
      }
    });
  }
}

function compare(a, b, isAsc) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
