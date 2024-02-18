export enum vehicleTypeEnum {
    Common,
    Luxury
}

export class VehicleRequest {
    vehicleBasePrice!: number;
    vehicleType!: vehicleTypeEnum;

    public constructor(init?: Partial<VehicleRequest>) 
    {
        Object.assign(this, init);
    }
}