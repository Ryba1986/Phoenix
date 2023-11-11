import { CreateCommandBase } from '../../base/commands/createCommandBase';

export interface CreateLocationCommand extends CreateCommandBase {
   name: string;
   includeReport: boolean;
}
