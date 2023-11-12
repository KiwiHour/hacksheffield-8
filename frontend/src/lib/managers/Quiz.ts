import ApiInterface from "./ApiInterface";

export default class Quiz extends ApiInterface {

    constructor(apiKey: string | null) {
        super(apiKey);
    }

    async submitAnswers(devicesInHousehold: string[], hoursAcOn: number, noBedrooms: number, noBulbs: number, bulbType: string) {
        
        let { data: bestMatchedId } = await this.apiFetch("test/setQuiz", "post", {
            "devices in household":devicesInHousehold,
            "Number of hours the aircon/heating is on per day": hoursAcOn,
            "Number of bedrooms in the house": noBedrooms,
            "Number of bulbs in the house": noBulbs,
            "The type of bulbs": bulbType
        })

        console.log(`best matched id: ${bestMatchedId}`)


        return -1;
    }
}