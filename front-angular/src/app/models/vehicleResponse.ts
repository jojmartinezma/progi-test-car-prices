export class VehicleResponse {
    basic!: number;
    special!: number;
    asosiation!: number;
    storage!: number;
    total!: number;

    public constructor(init?: Partial<VehicleResponse>) 
    {
        Object.assign(this, init);
    }
}