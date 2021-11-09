import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Country } from 'src/app/Model/country-model';
import { CountryService } from 'src/app/Services/country.service';
import { Location } from '@angular/common';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.css']
})
export class CountryDetailComponent implements OnInit {
  formValue!: FormGroup;
  editCountry = new FormGroup({
    Name: new FormControl('')
  })
  alert!: boolean;
  constructor(private route: ActivatedRoute,
    private countryService: CountryService,
    private router: Router) { }


  ngOnInit(): void {
    console.log(this.route.snapshot.params.id);
    this.countryService.getCountry(this.route.snapshot.params.id).subscribe((result) =>
      this.editCountry = new FormGroup({
        Name: new FormControl(result['Name'])
      })
    )
  }
  updateCountry() {
    this.countryService.updateCountry(this.editCountry.value, this.route.snapshot.params.id).subscribe((result) =>
      console.log(result, "data updated successfully"));
    this.router.navigate(['countries']);
  }
}



