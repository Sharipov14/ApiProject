import { Component, OnInit } from '@angular/core';
import { DataService } from 'src/app/data.service';
import { Distribution } from './distributions';

@Component({
    selector: 'distrib-comp',
    templateUrl: './distribution.component.html',
    providers: [DataService]
})
export class DistributionComponent implements OnInit {

    private url = "api/distributions";

    distribution: Distribution = new Distribution();   // изменяемый товар
    distributions: Distribution[];                // массив товаров
    tableMode: boolean = true;          // табличный режим

    constructor(private dataService: DataService) {}

    ngOnInit() {
        this.loadDistributions();    // загрузка данных при старте компонента  
    }

    // получаем данные через сервис
    loadDistributions() {
        this.dataService.getAll(this.url)
            .subscribe((data: Distribution[]) => this.distributions = data);
    }
    // сохранение данных
    save() {       
        if (this.distribution.id == null) {
            this.dataService.create(this.url ,this.distribution)
                .subscribe((data: Distribution) => this.distributions.push(data));
        } else {
            this.dataService.update(this.url ,this.distribution)
                .subscribe(data => this.loadDistributions());
        }
        this.cancel();
    }
    editDistribution(p: Distribution) {
        this.distribution = p;
    }
    cancel() {
        this.distribution = new Distribution();
        this.tableMode = true;
    }
    delete(p: Distribution) {
        this.dataService.delete(this.url ,p.id)
            .subscribe(data => this.loadDistributions());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}