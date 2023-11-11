import { CommandBase } from '../../base/commands/commandBase';

export interface UpdateUserPasswordCommand extends CommandBase {
   currentPassword: string;
   newPassword: string;
   confirmNewPassword: string;
}
