import { User } from "./user";

export interface Taskdetails {
  id: number;
  title: string;
  description: string;
  dueDate: string;
  status: string;
  user: User
}
