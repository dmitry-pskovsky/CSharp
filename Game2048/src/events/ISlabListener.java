package events;

import java.awt.*;

/**
 * Created by dimap on 10/15/2015.
 */
public interface ISlabListener {
    void initializeView(Point location, int value);
    void moveToLocation(Point location);
    void remove();
    void up(int value);
}
