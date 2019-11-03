import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgbModal, ModalDismissReasons, NgbModalRef  } from "@ng-bootstrap/ng-bootstrap";
import { FormGroup, FormBuilder, FormControl, Validators } from "@angular/forms";
import { Content } from "@angular/compiler/src/render3/r3_ast";
import { ToastrService} from 'ngx-toastr';

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  tasks: Task[];
  closeResult: string;
  addNewForm: FormGroup;
  private newItemModal: NgbModalRef;
  private newTask: Task = new Task();
  private currentTask: Task = new Task();
  private url: string;

  constructor(
    private modalService: NgbModal,
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private toastrService: ToastrService,
    @Inject("BASE_URL") baseUrl: string) {
    this.url = baseUrl + "task";
    http.get<Task[]>(this.url).subscribe(result => {
        this.tasks = result;
      },
      error => {
        console.error(error);
        this.tasks = [];
      });
    this.createForm();
  }

  private createForm() {
    this.addNewForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ''
    });
  }

  open(content) {
   this.newItemModal = this.modalService.open(content, { ariaLabelledBy: "modal-basic-title" });
  }

  private submitForm({value, valid}: { value: Task, valid: boolean }) {
    console.log(value);
    if (valid) {
      this.http.post(this.url , value).subscribe((resp: Task) => {
        console.log(resp);
        this.tasks.push(resp);
        this.toastrService.success('Success!');
      }, err => {
        console.log(err);
        this.toastrService.error('Error!');
      });
      this.addNewForm.reset();
      this.newItemModal.close();
    } else {
      this.toastrService.error('Error', 'Name cannot be empty!');
    }
  }

  private onCompleteClick(item: Task) {
    item.isComplete = true;
    this.http.put(`${this.url}/${item.id}` , item).subscribe((resp: Task) => {
      item.completeAt = resp.completeAt;
      this.toastrService.success('Success!');
      console.log(resp);
    }, err => {
      item.isComplete = false;
      this.toastrService.error('Error!');
      console.log(err);
    });
  }

  private openDetail(content: Content, item: Task) {
    this.currentTask = item;
    this.modalService.open(content);
  }
}

export class Task {
  id: number;
  name: string;
  description: string;
  createdAt: Date;
  completeAt: Date;
  isComplete: boolean;
}
