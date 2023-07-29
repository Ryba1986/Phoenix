import { ApiBase } from "./base/apiBase";
import { CreateClientCommand } from "../models/api/clients/commands/createClientCommand";
import { UpdateClientCommand } from "../models/api/clients/commands/updateClientCommand";
import { ClientDto } from "../models/api/clients/dto/clientDto";
import { ClientHistoryDto } from "../models/api/clients/dto/clientHistoryDto";
import { GetClientHistoryQuery } from "../models/api/clients/queries/getClientHistoryQuery";
import { Result } from "../models/requests/result";

export class ClientApi extends ApiBase {
   constructor() {
      super();
   }

   public getClientsAsync(): Promise<Array<ClientDto>> {
      return this._requestHelper.getAsync<Array<ClientDto>>("client/getClients");
   }

   public getClientHistoryAsync(request: GetClientHistoryQuery): Promise<Array<ClientHistoryDto>> {
      return this._requestHelper.getAsync<Array<ClientHistoryDto>>("client/getClientHistory", request);
   }

   public createClientAsync(command: CreateClientCommand): Promise<Result> {
      return this._requestHelper.postAsync("client/createClient", command);
   }

   public updateClientAsync(command: UpdateClientCommand): Promise<Result> {
      return this._requestHelper.postAsync("client/updateClient", command);
   }
}
