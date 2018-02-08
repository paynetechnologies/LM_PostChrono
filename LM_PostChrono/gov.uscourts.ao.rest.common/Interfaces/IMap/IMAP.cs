namespace gov.uscourts.ao.rest.common.Interfaces.IMAP
{
    public interface IMAP<Input, OutPut>
    {
        OutPut MapFrom(Input input);
    }
}
