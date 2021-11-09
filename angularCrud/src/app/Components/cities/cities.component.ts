import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { City } from 'src/app/Model/city-model';
import { Country } from 'src/app/Model/country-model';
import { CountryService } from 'src/app/Services/country.service';
import { CitiesService } from 'src/app/Services/cities.service';
@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {
  countryList: Country[] = new Array();
  formValue!: FormGroup;
  cities: City[] = [];
  constructor(private formBuilder: FormBuilder, private cityService: CitiesService,
    public countryService: CountryService, private router: Router
  ) { }

  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      Name: [''],
      CountryId: [0],
      CountryName: ['']
    })
    this.getCity();
    this.countryService.getCountries().subscribe(country => {
      this.countryList = country;
    })
  }
  getCity() {
    this.cityService.getCities().subscribe(res => {
      this.cities = res;
    })
  }
  addCity(): void {
    console.log(this.formValue);
    this.cityService.addCity(this.formValue.value)
      .subscribe(c => {
        this.cities.push(c);
      });

  }
  delete(city: City): void {
    alert("Deleted successfully")
    this.cities = this.cities.filter(h => h !== city);
    this.cityService.deleteCity(city.Id).subscribe();
  }
  editButtonClick(cityId: number) {
    this.router.navigate(['cityedit/', cityId]);
  }
}
