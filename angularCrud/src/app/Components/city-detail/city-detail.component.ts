import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CitiesService } from 'src/app/Services/cities.service';
@Component({
  selector: 'app-city-detail',
  templateUrl: './city-detail.component.html',
  styleUrls: ['./city-detail.component.css']
})
export class CityDetailComponent implements OnInit {
  formValue!: FormGroup;
  editCity = new FormGroup({
    Name: new FormControl(''),
    CountryId: new FormControl('')
  })
  constructor(private route: ActivatedRoute,
    private cityService: CitiesService,
    public router: Router) { }

  ngOnInit(): void {
    console.log(this.route.snapshot.params.id);
    this.cityService.getCity(this.route.snapshot.params.id).subscribe((result) =>
      this.editCity = new FormGroup({
        Name: new FormControl(result['Name']),
        CountryId:new FormControl(result['CountryId'])
      })
    )
  }
  updateCity() {
    this.cityService.updateCity(this.editCity.value, this.route.snapshot.params.id).subscribe((result) =>
      console.log(result, "data updated successfully"));
    this.router.navigate(['cities']);
  }
}
