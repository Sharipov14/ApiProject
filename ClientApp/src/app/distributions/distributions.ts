export class Distribution {
    constructor(
        public id?: number,
        public workerId?: number,
        public projectId?: number,
        public dateStart?: string | Date,
        public hours?: number) {}
}