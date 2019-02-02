package events;

import model.Slab;

/**
 * Created by dimap on 10/15/2015.
 */
public interface IGridListener {
    void createSlab(Slab slab);
    void repaint();
}
