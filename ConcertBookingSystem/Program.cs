// See https://aka.ms/new-console-template for more information

public class Concert
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public int AvailableSeats { get; set; }

    public Concert(string name, DateTime date, string location, int availableSeats)
    {
        this.Name = name;
        this.Date = date;
        this.Location = location;
        this.AvailableSeats = availableSeats;
    }
}
public class Ticket
{
    public Concert Concert { get; set; }
    public int Price { get; set; }
    public int SeatNumber { get; set; }

    public Ticket(Concert concert, int price, int seatNumber)
    {
       this.Concert = concert;
       this.Price = price;
       this.SeatNumber = seatNumber;
    }
}

public class BookingSystem
{
    private List<Concert> concerts = new List<Concert>();
    private List<Ticket> tickets = new List<Ticket>();
    
    public void AddConcert(Concert concert)
    {
        concerts.Add(concert);
    }
    
    public bool BookTicket(Concert concert,int price, int seatNumber)
    {
        if (concert.AvailableSeats <= 0)
        {
            return false; 
        }
        else
        {
            concert.AvailableSeats--;
            var ticket = new Ticket(concert, price, seatNumber); 
            tickets.Add(ticket);
            return true;   
        }
    }
    public List<Concert> GetConcertsByDate(DateTime date)
    {
        return concerts.Where(concert => concert.Date.Date == date.Date).ToList();
    }
    
    public List<Concert> GetConcertsByLocation(string location)
    {
        return concerts.Where(concert => concert.Location.Contains(location)).ToList();
    }
}