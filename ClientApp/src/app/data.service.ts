import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataService {

    constructor(private http: HttpClient) {
    }

    getAll(url: string) {
        return this.http.get(url);
    }

    get(url: string, id: number) {
        return this.http.get(url + '/' + id);
    }

    create(url: string, data: any) {
        return this.http.post(url, data);
    }
    update(url: string, data: any) {
        return this.http.put(url, data);
    }
    delete(url: string, id: number) {
        return this.http.delete(url + '/' + id);
    }
}