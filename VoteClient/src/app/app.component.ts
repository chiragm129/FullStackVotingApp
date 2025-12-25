import { Component, OnInit } from '@angular/core';
import { VotingService } from './services/voting.service';
import { Voter } from './models/Voter';
import { Candidate } from './models/Candidate';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports:[FormsModule,CommonModule],
  standalone: true,
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  voters: Voter[] = [];
  candidates: Candidate[] = [];

  selectedVoterId!: number;
  selectedCandidateId!: number;

  constructor(private votingService: VotingService) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.votingService.getVoters().subscribe(res => this.voters = res);
    this.votingService.getCandidates().subscribe(res => this.candidates = res);
  }

  submitVote() {
    if (!this.selectedVoterId || !this.selectedCandidateId) {
      alert('Please select voter and candidate');
      return;
    }

    this.votingService
      .castVote(this.selectedVoterId, this.selectedCandidateId)
      .subscribe({
        next: () => {
          alert('Vote cast successfully');
          this.loadData()
          this.selectedVoterId = 0;
          this.selectedCandidateId = 0;
        },
        error: err => {
          alert(err.error);
        }
      });
  }
}
