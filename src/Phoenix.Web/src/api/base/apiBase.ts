import { RequestHelper } from "../../helpers/requestHelper";

export abstract class ApiBase {
   protected readonly _requestHelper: RequestHelper;

   constructor() {
      this._requestHelper = new RequestHelper();
   }
}
