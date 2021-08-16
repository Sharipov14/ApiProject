import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { Worker } from './worker';

@Component({
    selector: 'worker-comp',
    templateUrl: './worker.component.html',
    providers: [DataService]
})
export class WorkerComponent implements OnInit {

    private url = "api/workers";

    worker: Worker = new Worker();   // изменяемый товар
    workers: Worker[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) {}

    ngOnInit() {
        this.loadWorkers();    // загрузка данных при старте компонента  
    }

    // получаем данные через сервис
    loadWorkers() {
        this.dataService.getAll(this.url)
            .subscribe((data: Worker[]) => this.workers = data);
    }
    // сохранение данных
    save() {       
        if (this.worker.workerId == null) {
            this.dataService.create(this.url, this.worker)
                .subscribe((data: Worker) => this.workers.push(data));
        } else {
            this.dataService.update(this.url, this.worker)
                .subscribe(data => this.loadWorkers());
        }
        this.cancel();
    }
    editWorker(w: Worker) {
        this.worker = w;
    }
    cancel() {
        this.worker = new Worker();
        this.tableMode = true;
    }
    delete(w: Worker) {
        this.dataService.delete(this.url, w.workerId)
            .subscribe(data => this.loadWorkers());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}