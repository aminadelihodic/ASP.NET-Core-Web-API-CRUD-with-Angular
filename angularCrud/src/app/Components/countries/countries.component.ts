import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Country } from 'src/app/Model/country-model';
import { CountryService } from 'src/app/Services/country.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css']
})
export class CountriesComponent implements OnInit {
  formValue!: FormGroup;
  countries: Country[] = [];
  constructor(private formBuilder: FormBuilder, private countryService: CountryService, private router: Router) { }

  ngOnInit(): void {
    this.getCountry();
    this.formValue = this.formBuilder.group({
      Name: ['']
    });
  }

  getCountry() {
    this.countryService.getCountries().subscribe(res => {
      this.countries = res;
    })
  }
  add(): void {
    this.countryService.addCountry(this.formValue.value)
      .subscribe(c => {
        this.countries.push(c);
      });
  }
  delete(country: Country): void {
    alert("Deleted successfully")
    this.countries = this.countries.filter(h => h !== country);
    this.countryService.deleteCountry(country.Id).subscribe()
  }

  editButtonClick(countryId: number) {
    this.router.navigate(['/edit', countryId]);
  }
}