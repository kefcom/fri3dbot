export class Face {
    id: number;
    name: string;
    humanName: string;
  }

export class FaceDTO{
  /**
   *
   */
  constructor(faceId:number, code:number) {
    this.FaceId = faceId;
    this.AuthorizationCode = code;
  }
  FaceId: number;
  AuthorizationCode: number;
}