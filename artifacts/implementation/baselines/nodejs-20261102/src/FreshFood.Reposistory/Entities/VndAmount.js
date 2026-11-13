/**
 * Design revision 2026-11-02: VndAmount
 * Ownership: FreshFood.Reposistory.Entities
 * - units: bigint
 * + FromUnits(units: bigint): VndAmount {static}
 * + Add(other: VndAmount): VndAmount
 * + ToWire(): string
 */
export class VndAmount {
  #units;
  constructor(units){if(typeof units!=='bigint'||units<0n)throw new RangeError('VND requires nonnegative bigint units');this.#units=units;Object.freeze(this);}
  static FromUnits(units){return new VndAmount(units);}
  Add(other){if(!(other instanceof VndAmount))throw new TypeError('VndAmount required');return new VndAmount(this.#units+other.#units);}
  ToWire(){return this.#units.toString();}
  toString(){return this.ToWire();}
  toJSON(){return this.ToWire();}
}
