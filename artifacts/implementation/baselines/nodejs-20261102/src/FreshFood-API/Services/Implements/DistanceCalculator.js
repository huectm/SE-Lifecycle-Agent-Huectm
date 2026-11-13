/**
 * Design revision 2026-11-02: DistanceCalculator
 * Ownership: FreshFood-API.Services.Implements
 * - gateway: IDistanceGateway
 * + DistanceCalculator(gateway: IDistanceGateway)
 * + CalculateAsync(addressId: EntityId, signal: AbortSignal): Promise<number>
 */
export class DistanceCalculator { constructor(distanceGateway) { this.distanceGateway=distanceGateway; } async CalculateAsync(addressId, signal) { return this.distanceGateway.DrivingDistanceAsync(addressId, signal); } }
