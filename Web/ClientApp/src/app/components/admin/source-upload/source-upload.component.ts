import { SourceItem } from './../../../models/bidding/pricereference/sourceitem.model';
import { FileUploadService } from './../file-upload-service/file-upload.service';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-source-upload',
    templateUrl: './source-upload.component.html',
    styleUrls: ['./source-upload.component.css']
})
export class SourceUploadComponent implements OnInit {
    isOk: boolean = false;

    constructor(
        private fileUploadService: FileUploadService
    ) { }

    ngOnInit(): void {
        
    }

    // inputFileChange(event: any){
    //     if (event.target.files && event.target.files[0]){
    //         const _csv = event.target.files[0];

    //         const fileReader = new FileReader();

    //         // this.csvContent = event.target.

    //         const formData = new FormData();
    //         formData.append('csv',_csv);


    //         // this.fileUploadService.postSourceItem(_sourceItem);
    //     }
    // }
    onChange(event: any) {
        console.log(event);

        const selectedFiles = <FileList>event.target.files;
        console.log(selectedFiles[0]);

        const fileToRead = selectedFiles[0];

        const reader = new FileReader();
        reader.readAsText(fileToRead);

        reader.onload = (e) => {

            let csv: string = <string>reader.result;
    
            let allTextLines = csv.split('\n');

            for (let i = 0; i < allTextLines.length; i++){
                let data = allTextLines[i].split('\t');
                
                let sourceItem = new SourceItem();
                sourceItem.code = data[0];
                sourceItem.description = data[1];
                sourceItem.unit = data[2];
                sourceItem.sourceId = 1;

                if (data[3] == '' || null){
                    sourceItem.material = 0;
                }
                else{
                    sourceItem.material = Number.parseFloat(data[3]);
                }

                if (data[4] == '' || null){
                    sourceItem.manpower = 0;
                }
                else{
                    sourceItem.manpower = Number.parseFloat(data[4]);
                }

                if (data[5] == '' || null){
                    sourceItem.totalUnitValue = 0;
                }
                else{
                    sourceItem.totalUnitValue = Number.parseFloat(data[5]);
                }

                if (sourceItem.manpower != null && sourceItem.material != null && sourceItem.totalUnitValue != null){
                    this.fileUploadService.postSourceItem(sourceItem).subscribe(
                        result => {
                            console.log("item inserido: " + sourceItem.code);
                        },
                        err => {
                            console.log("Ocorreu um erro: ", err);                        
                        }
                    );
                }                
            }
            this.isOk = true;
        }
    }


}
