describe('Clean Code Lab 5 Tests', () => {
    it('Find id of original bug in db', () => {
        cy.visit('http://localhost:1234');
        cy.get('#tableBugs').eq(0).should('contain', '8722df98-f574-4d3a-b7b4-38d7c062cd5a')
    })

    it('Create new bug', () => {
        cy.get('#createBugLink').click()
        cy.get('#bugTextInput').type("Testbug")
        cy.get('#authorInput').type("TestbugAuthor")
        cy.get('#submitBug').click();
    })

    it('Update bug', () => {
        cy.contains('Testbug').parent('tr').within(() => {
            cy.get('td').eq(3).contains('Edit').click()
        })
        cy.get('#editBugText').type("Updated text")
        cy.get('#editBugSubmit').click()
    })

    it('Delete bug', () => {
        cy.contains('Updated text').parent('tr').within(() => {
            cy.get('td').eq(4).contains('Delete').click()
        })
    })

    it('Count', () => {
        //cy.get('.parentClass').get('.childClass').should('have.length', expectedCount);
        cy.get('#bodyOfBugs').find('tr').should('have.length', 1)
    })
})