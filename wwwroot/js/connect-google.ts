@Injectable()
export class RaceService {
    constructor(private _http:Http) {
    }

    getRaceById(id): Observable<any> {
        return this._http.get(`/api/races/${id}`)
                         .map(response => response.json());
    }
}