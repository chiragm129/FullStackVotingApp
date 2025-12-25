import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Voter } from '../models/Voter';
import { Candidate } from '../models/Candidate';

@Injectable({
  providedIn: 'root'
})

export class VotingService {
  private baseUrl = 'http://localhost:5000/api';

  constructor(private http: HttpClient) { }

  getVoters(): Observable<Voter[]> {
    return this.http.get<Voter[]>(`${this.baseUrl}/voters`);
  }

  getCandidates(): Observable<Candidate[]> {
    return this.http.get<Candidate[]>(`${this.baseUrl}/candidates`);
  }

  castVote(voterId: number, candidateId: number) {
    return this.http.post(`${this.baseUrl}/votes/cast`, {
      voterId,
      candidateId
    });
  }
}
