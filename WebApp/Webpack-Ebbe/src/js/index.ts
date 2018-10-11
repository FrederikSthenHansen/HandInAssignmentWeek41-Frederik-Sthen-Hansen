


const  GramsPrOunce : number = 28.34952;
let Calculation: string= "";

let g2oButton: HTMLButtonElement= <HTMLButtonElement> document.getElementById("g2o");
let O2GButton: HTMLButtonElement= <HTMLButtonElement> document.getElementById("o2g")
let resultLine: HTMLDivElement= <HTMLDivElement> document.getElementById("resultLine");

g2oButton.addEventListener ("click", G2OButtonMethod ); 
O2GButton.addEventListener("click", O2GButtonMethod);


function G2OButtonMethod (): void
{
Calculation=GramsToOunces()+" Ounces";
resultLine.innerHTML=Calculation;
}

function O2GButtonMethod():void
{
Calculation= OuncesToGrams()+ " Grams";
resultLine.innerHTML=Calculation;
}

function GramsToOunces(): number
{ 
 let el: HTMLInputElement= <HTMLInputElement> document.getElementById ('inWeight');
     let weight: number = +el.value; 

   return weight/GramsPrOunce;
}

function OuncesToGrams(): number
{
  let el: HTMLInputElement= <HTMLInputElement> document.getElementById ('inWeight');
  let weight: number = +el.value
  return weight*GramsPrOunce;
}