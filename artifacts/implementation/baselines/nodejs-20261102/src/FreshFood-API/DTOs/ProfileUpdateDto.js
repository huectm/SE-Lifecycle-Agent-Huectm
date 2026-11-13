/**
 * Design revision 2026-11-02: ProfileUpdateDto
 * Ownership: FreshFood-API.DTOs
 * + FullName: string
 * + Email: string?
 */
/** ProfileUpdateDto — FreshFood-API.DTOs; approved design source: detailed-class-model.json. */
export class ProfileUpdateDto {
  constructor(values = {}) {
    this.FullName = values.FullName;
    this.Email = values.Email;
  }
}
