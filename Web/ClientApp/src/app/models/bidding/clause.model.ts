export class Clause {

    /**
     *
     */
    constructor(
        public clauseId: number,
        public number: string,
        public text: string,
        public closed: boolean,
        public contractId: number,
        public additiveId: number
    ) {
        

    }
  
}
