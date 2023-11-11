import { getAsync, postAsync } from '../helpers/requestHelper';
import { CreateClientCommand } from '../models/api/clients/commands/createClientCommand';
import { UpdateClientCommand } from '../models/api/clients/commands/updateClientCommand';
import { ClientDto } from '../models/api/clients/dto/clientDto';
import { ClientHistoryDto } from '../models/api/clients/dto/clientHistoryDto';
import { GetClientHistoryQuery } from '../models/api/clients/queries/getClientHistoryQuery';
import { Result } from '../models/requests/result';

export function getClientsAsync(): Promise<Array<ClientDto>> {
   return getAsync<Array<ClientDto>>('client/getClients');
}

export function getClientHistoryAsync(request: GetClientHistoryQuery): Promise<Array<ClientHistoryDto>> {
   return getAsync<Array<ClientHistoryDto>>('client/getClientHistory', request);
}

export function createClientAsync(command: CreateClientCommand): Promise<Result> {
   return postAsync('client/createClient', command);
}

export function updateClientAsync(command: UpdateClientCommand): Promise<Result> {
   return postAsync('client/updateClient', command);
}
