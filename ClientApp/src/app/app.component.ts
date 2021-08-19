import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
})
export class AppComponent {

    isWorker: boolean = false;
    isProject: boolean = false;
    isDistribution: boolean = false;
    // isPossibleProject: boolean = false;

    runWorkers() {
        this.isWorker = true;
        this.isProject = false;
        this.isDistribution = false;
        // this.isPossibleProject = false;
    }

    runProjects() {
        this.isProject = true;
        this.isWorker = false;
        this.isDistribution = false;
        // this.isPossibleProject = false;
    }

    runDistributions() {
        this.isDistribution = true;
        this.isProject = false;
        this.isWorker = false;
        // this.isPossibleProject = false;
    }

    // runPossibleProject() {
    //     this.isPossibleProject = true;
    //     this.isDistribution = false;
    //     this.isProject = false;
    //     this.isWorker = false;
    // }
}